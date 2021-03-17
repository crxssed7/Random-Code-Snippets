// Generate a random number between 1 - 100
let rand = Math.floor((Math.random() * 100) + 1);

// A get request using JQuery. Get the data from JsonPlaceHolder, then update the UI accordingly
$.get(
    "https://jsonplaceholder.typicode.com/todos/1",
    function(data) {
       console.log(data);

       document.getElementById("title").innerHTML += data.title;
       document.getElementById("objId").innerHTML += data.id;
       document.getElementById("objCustId").innerHTML += data.userId;
       document.getElementById("completed").checked = data.completed;
    }
);

// Read from a file
$.get(
    "path/to/file.txt",
    function(data) {
       console.log(data);
    }
);
