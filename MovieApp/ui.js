class UI{
    constructor(){
        this.Name = document.getElementById('Name');
        this.Description = document.getElementById('Description');
        this.Type = document.getElementById('Type');
        this.Director = document.getElementById('Director');
        this.IMDbRate = document.getElementById('IMDbRate');
        this.alertMessage = document.getElementById('alert-message');
        this.UMovieId = document.getElementById('UMovieId');
        this.UName = document.getElementById('UName');
        this.UDescription = document.getElementById('UDescription');
        this.UType = document.getElementById('UType');
        this.UDirector = document.getElementById('UDirector');
        this.UIMDbRate = document.getElementById('UIMDbRate');
        this.movieListContainer = document.getElementById('movie-list-container');
        this.movieUpdateContainer = document.getElementById('movie-update-container');
        this.movieAddContainer = document.getElementById('movie-add-container');
      
       
    }

     clearAddForm(){
        this.Name.value = "";
        this.Description.value = "";
        this.Type.value = "";
        this.Director.value = "";
        this.IMDbRate.value = "";
    }
    
     clearUpdateForm(){
        this.UMovieId.value = "";
        this.UName.value = "";
        this.UDescription.value = "";
        this.UType.value = "";
        this.UDirector.value = "";
        this.UIMDbRate.value = "";
    }
    
     successAlert(message){
        const element = document.createElement('div');
        element.className = "alert alert-success";
        element.innerText = message;
        this.alertMessage.appendChild(element);
    
        setTimeout(() => {
            element.remove();
        }, 2000);
        
    }

    resetMovieList(){
        document.getElementById('cardGroup').remove();
        let element = document.createElement("div");
        element.id = "cardGroup";
        element.className = "row";
        const card_group = document.querySelector('.card-group');
        const child = document.getElementById('child');
        card_group.insertBefore(element,child);
    }

    errorAlert(message){
        const element = document.createElement('div');
        element.className = "alert alert-danger";
        element.innerText = message;
        this.alertMessage.appendChild(element);
    
        setTimeout(() => {
            element.remove();
        }, 2000);
        
    }

    


    movieAddConfig(){
        this.movieListContainer.style.display = 'none';
        this.movieUpdateContainer.style.display = 'none';
        this.movieAddContainer.style.display = 'block';
    }

    movieListConfig(){
        this.movieAddContainer.style.display = 'none';
        this.movieUpdateContainer.style.display = 'none';
        this.movieListContainer.style.display = 'block';

    }

    movieUpdateConfig(){
        this.movieAddContainer.style.display = 'none';
        this.movieUpdateContainer.style.display = 'block';
        this.movieListContainer.style.display = 'none';
    }

    getAddFormValues(){
        const movieDto = new Object();

        movieDto.Name = Name.value;
        movieDto.Description = Description.value;
        movieDto.Type = Type.value;
        movieDto.IMDbRate = IMDbRate.value;
        movieDto.Director = Director.value;

        return movieDto;

    }

    getUpdateFormValues(){
        const movieDto = new Object();

        movieDto.MovieId = UMovieId.value;
        movieDto.Name = UName.value;
        movieDto.Description = UDescription.value;
        movieDto.Type = UType.value;
        movieDto.IMDbRate = UIMDbRate.value;
        movieDto.Director = UDirector.value;

        return movieDto;

    }

    setUpdateFormDetail(movieDetail){
        this.UMovieId.value = movieDetail.MovieId;
        this.UName.value = movieDetail.Name;
        console.log(this.UName.value);
        this.UDescription.value = movieDetail.Description;
        this.UType.value = movieDetail.Type;
        this.UIMDbRate.value = movieDetail.IMDbRate;
        this.UDirector.value = movieDetail.Director;

    }
}






