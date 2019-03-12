﻿
var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();

//Disable send button until connection is established
document.getElementsByClassName("gsSubmit").disabled = true;
//document.getElementById("sendButton").disabled = true;

connection.on("UpdateSpace", function (x, y) {
    //var msg = y.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = x + " says " + msg;
    console.log(x, ' x');
    console.log(y, ' y');
    console.log(""+ x + y);
    var td = document.getElementById("" + x + y);
    var p = document.getElementById("" + x + y + " p");
    console.log(td, "td");
    td.setAttribute('class', 'hideSquare');
    p.setAttribute('class', 'un-hideSquare');
});

connection.on("ErrorMessage", function (x, y) {
    //var msg = y.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = x + " says " + msg;
    console.log(x, ' x');
    console.log(y, ' y');
    var td = document.getElementById("" + x + y);
    console.log(td);
    td.setAttribute('class', 'ColorChange2');
});

var createBoard = () => {
    let board = document.getElementById('gameboard');
    console.log(board);
    for (let i = 0; i < 9; i++) {
        let row = document.createElement('tr');
        console.log(row);
        for (let j = 0; j < 9; j++) {
            let column = document.createElement('td');
            let id = i.toString() + j.toString();
            column.setAttribute('id', id + `col`);
            let xInput = document.createElement('input');
            xInput.setAttribute('id', id + 'x');
            xInput.setAttribute('type', 'hidden');
            xInput.setAttribute('value', i);
            let yInput = document.createElement('input');
            yInput.setAttribute('id', id + 'y');
            yInput.setAttribute('type', 'hidden');
            yInput.setAttribute('value', j);
            let input = document.createElement('input');
            input.setAttribute('class', 'gsSubmit');
            input.setAttribute('type', 'number');
            input.setAttribute('id', id );
            input.append('test');
            column.appendChild(xInput);
            column.appendChild(yInput);
            column.appendChild(input);
            row.appendChild(column);
        }
        board.appendChild(row);
    }
    console.log(board);
}

connection.start().then(function () {
    //createBoard();
    addSignalListeners();
    document.getElementsByClassName('gsSubmit').disabled = false;
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

function addSignalListeners() {

    for (let i = 0; i < 9; i++) {
        for (let j = 0; j < 9; j++) {
            let id = '' + i + j;
            $('#' + id).change(() => {
                console.log(this);
                var x = document.getElementById(id + ` x`).value;
                var y = document.getElementById(id + ` y`).value;
                var boardID = document.getElementById(id + ' boardID').value;
                var val = document.getElementById(id).value;
                console.log(x);
                console.log(y);
                connection.invoke('SendCoordinate', x, y, boardID, val).catch(function (err) {
                    return console.error(err.toString());
                });
            });
        }
    }   
}



