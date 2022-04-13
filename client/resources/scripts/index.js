const baseUrl = "https://localhost:8001/api/Song";
var songList = [];
var mySong = {};

function handleOnLoad() {
    populatePage();
}

function populatePage(){

    const allSongsApiUrl = baseUrl;
    fetch(allSongsApiUrl).then(function(response){
        return response.json();
    }).then(function(json){ // asyncronous call
        songList = json;
        let html = `<div class = "row">`;
        json.forEach((song)=>{
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
            html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
            if (song.favorited == "True") {
                html += `<button class = "button" id = `+song.songID+` class="btn btn-transparent" onclick="handleUnFavoriteClick(`+song.songID+`)">❤️</button>`;
                html += `<button class = "button" id = `+song.songID+` class="btn btn-transparent" onclick="handleDeleteClick(`+song.songID+`)">🗑️</button>`;
            }
            else {
                html+= `<button class = "button" id = `+song.songID+` class="btn btn-white" onclick="handleFavoriteClick(`+song.songID+`)">♡</button>`;
                html+= `<button class = "button" id = `+song.songID+` class="btn btn-transparent" onclick="handleDeleteClick(`+song.songID+`)">🗑️</button>`;
            }
            html += `</div>`;
            html += `</div>`;
        })
        html += `</div>`;
        document.getElementById("cards").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    });
}

function handleAddClick() {
    postSong();
}

function handleDeleteClick(id) {
    deleteSong(id);
}

function handleUnFavoriteClick(id) {
    putSong(id);
}

function handleFavoriteClick(id) {
    putSong(id);
}

function postSong(){
    const postSongApiUrl = baseUrl;
    const sendSong = {
        songTitle: document.getElementById("title").value,
    }
    fetch(postSongApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(sendSong)
    })
    .then((response)=>{
        mySong = sendSong;
        populatePage();
        blankFields();
    });
}

function putSong(id){
    console.log(id);
    const putSongApiUrl = baseUrl + "/" + id;
    console.log("made it here");
    const sendSong = {
        songID : id,
    }
    fetch(putSongApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(sendSong)
    })
    .then((response)=>{
        mySong = sendSong;
        populatePage();
        blankFields();
    });
}

function deleteSong(id){
    console.log(id);
    const deleteSongApiUrl = baseUrl + "/" + id;
    console.log("made it here");
    fetch(deleteSongApiUrl, {
        method: "DELETE"
    })
    .then((response)=>{
        populatePage();
        blankFields();
    });
}

// function deleteBook(){
//     const deleteBookApiUrl = baseUrl + "/" + myBook.id;
//     fetch(deleteBookApiUrl, {
//         method: "DELETE",
//         headers: {
//             "Accept": 'application/json',
//             "Content-Type": 'application/json',
//         }
//     })
//     .then((response)=>{
//         blankFields();
//         populateList();
//     });
// }

function blankFields()
{
    document.getElementById("title").value = "";
}

function findSongs(){
    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.title+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}