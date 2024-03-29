﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/gamehub").build();

//Disable send button until connection is established
document.getElementsByClassName("gsSubmit").disabled = true;
//document.getElementById("sendButton").disabled = true;

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("NewBoardReady", function () {
    var butt = document.getElementById("win-contain");
    butt.setAttribute('class', 'un-hideSquare');

});

connection.on("BoardComplete", function () {
    var table = document.getElementById("main")
    var butt = document.getElementById("you-win");
    butt.setAttribute('class', 'un-hideSquare');
    table.setAttribute('class', 'win');

});

connection.on("UpdateSpace", function (x, y) {
    var td = document.getElementById("" + x + y);
    var p = document.getElementById("" + x + y + " p");
    var table = document.getElementById("table-board")
    td.setAttribute('class', 'hideSquare');
    p.setAttribute('class', 'un-hideSquare');
    table.setAttribute('class', 'nosalt');

});

connection.on("ErrorMessage", function (x, y) {
    var td = document.getElementById("" + x + y);
    var table = document.getElementById("table-board")
    td.setAttribute('class', 'ColorChange2');
    table.setAttribute('class', 'saltShaker');
});

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user;
    var encodedMsg2 = ": " + msg;
    var li = document.createElement("li");
    var i = document.createElement("i");
    i.setAttribute('class', 'fas fa-comment-alt');
    li.textContent = encodedMsg;
    li.appendChild(i);
    var li2 = document.createElement("i");
    li2.textContent = encodedMsg2;
    document.getElementById("messagesList").appendChild(li).appendChild(li2);
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
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

function addSignalListeners() {

    for (let i = 0; i < 9; i++) {
        for (let j = 0; j < 9; j++) {
            let id = '' + i + j;
            $('#' + id).change(() => {
                var x = document.getElementById(id + ` x`).value;
                var y = document.getElementById(id + ` y`).value;
                var boardID = document.getElementById(id + ' boardID').value;
                var val = document.getElementById(id).value;
                connection.invoke('SendCoordinate', x, y, boardID, val).catch(function (err) {
                    return console.error(err.toString());
                });
            });
        }
    }
    document.getElementById("sendButton").addEventListener("submit", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
    });

}

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    var encodedMsg = user + " says " + msg;
//    var li = document.createElement("li");
//    li.textContent = encodedMsg;
//    document.getElementById("messagesList").appendChild(li);
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});


