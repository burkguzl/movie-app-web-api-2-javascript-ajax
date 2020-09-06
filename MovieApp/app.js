
//select element

const movieAddForm = document.getElementById('movie-add-form');
const movieUpdateForm = document.getElementById('movie-update-form');
const navbarAddButton = document.getElementById('navbar-add-button');
const navbarListButton = document.getElementById('navbar-list-button');
const movieApi = new Movie();
const ui = new UI();

//add event listener
eventListeners();

function eventListeners(){
    movieAddForm.addEventListener('submit', addMovie);
    movieUpdateForm.addEventListener('submit', updateMovie);
    navbarAddButton.addEventListener('click', getAddForm);
    navbarListButton.addEventListener('click', getListForm);
    document.addEventListener('DOMContentLoaded', getMovieList);
}

function getMovieList(){

   ui.resetMovieList();
        
    ui.movieListConfig();

    movieApi.getMovie().then(data => {
        data.Data.forEach(data => {
            
            cardGroup.innerHTML += `
            
            <div class="card col-md-3 mr-5 ml-5 mb-2 text-center mr-3">
                        <img src="movieImg.png" class="card-img-top" alt="...">.
                        <div><span>IMDb Rate </span><span class="badge badge-dark">${data.IMDbRate} </span><span> Type</span> <span class="badge badge-secondary"> <span>${data.Type}</span></div>
                        <div class="card-body">
                            
                          <h5 class="card-title">${data.Name}</h5>
                          <p class="card-text">${data.Description}</p>
                          <p class="card-text"><small class="text-muted">${data.Director}</small></p>
                          <div><button onclick="editMovie(this) " type="button" value="${data.MovieId}" class="btn btn-secondary">Edit</button> <button value="${data.MovieId}" onclick="deleteMovie(this)" type="button" class="btn btn-dark">Delete</button></div>
                        </div>
                      </div>
                      
            `
        });
        ui.successAlert('Filmler listelendi');
    }).catch(err => {
        ui.successAlert('Hata oluştu');
    });
    
}

function addMovie(e){
    const movieDto = ui.getAddFormValues();
    movieApi.addMovie(movieDto)
    .then(response => {
        console.log(response);
    })
    .then(function (){
        ui.clearAddForm();
        ui.movieListConfig();
        ui.removeMovieList();
        getMovieList();
    })
    .catch(err => {
        console.log(err);
    })


    e.preventDefault();
}

function updateMovie(e){

    const movieDto = ui.getUpdateFormValues();
    console.log(movieDto);

    movieApi.updateMovie(movieDto).then(response => {
        console.log('Response',response);
    })
    .then(function (){
        ui.clearUpdateForm();
        ui.movieListConfig();
        getMovieList();
    })
    .catch(err => {
        console.log(err);
    })


 e.preventDefault();
}

function getAddForm(){
    ui.movieAddConfig();
    ui.clearAddForm();
}

function getListForm(){
    ui.movieListConfig();
}

function editMovie(element){
    const id = element.value;
    movieApi.getMovieDetail(id)
    .then(response => {
        console.log('Data',response.Data);
        ui.setUpdateFormDetail(response.Data)}).then(function(){
            ui.movieUpdateConfig();
        })
    .catch(err => console.log(err));
   
}

function deleteMovie(element){
    const id = element.value;
    movieApi.deleteMovie(id)
    .then(response => console.log(response)).then(function(){
        getMovieList();
    })
    .catch(err => console.log(err))
}







