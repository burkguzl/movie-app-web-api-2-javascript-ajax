class Movie{
    constructor(){
        this.endpoint = 'https://localhost:44354/api/movies';
    }

    async getMovie(){
        const responseData = await $.ajax({
            url:this.endpoint,
            type: 'GET',
            dataType: 'json'
        })

        return responseData;
    }

    async deleteMovie(id){
        const responseData = await $.ajax({
            url:this.endpoint + '/delete/' + id,
            type: 'GET',
            dataType: 'json'
        })

        return responseData;
    }

    async addMovie(movie){
        const responseData = await $.ajax({
            url: this.endpoint,
            type: 'POST',
            dataType :'json',
            data: movie
        });

        return responseData;
    }

    async updateMovie(movie){
        const responseData = await $.ajax({
            url: this.endpoint + '/update/' + movie.MovieId,
            type: 'POST',
            dataType :'json',
            data: movie
        });

        console.log(responseData);

        return responseData;
    }


    async getMovieDetail(id){
        console.log(id);
        const reponseData = await $.ajax({
            url: 'https://localhost:44354/api/movies/'+id,
            type: 'GET',
            dataType :'json',
            data: id
        })

        return reponseData;
    }
}