

var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

//Disable send button until connection is established
document.getElementsByClassName("gsSubmit").disabled = true;
//document.getElementById("sendButton").disabled = true;

connection.on("UpdateSpace", function (x, y) {
    //var msg = y.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = x + " says " + msg;
    var td = document.getElementById("" + x + y);
    td.css('background-color', 'red');
});

connection.start().then(function () {
    document.getElementsByClassName('gsSubmit').disabled = false;
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
    });

//function addListen() {
//    console.log("listening");
//    var subButt = document.getElementsByClassName('gsSubmit');
//    console.log(subButt);
//    for (i = 0; i < subButt.length; i++) {
//        var item = subButt[i]fa;
//        console.log(item);
//        subButt[i].click(function (event) {
//            console.log("listening222");

//            var x = item.siblings().first().value;
//            var y = item.siblings().eq(1).value;
//            connection.invoke("SendCoordinate", x, y).catch(function (err) {
//                return console.error(err.toString());
//            });
//            event.preventDefault();
//        });
//    };s
//}
function addSignalListeners() {
    $('.gsSubmit').click(() => {
        var x = $(this).siblings().first().value;
        var y = $(this).siblings().eq(2).value;
        // send x and y to hub
        connection.invoke("SendCoordinate", x, y).catch(function (err) {
            return console.error(err.toString());
        });
    });

}
$(document).ready(addSignalListeners);


     
//document.getElementsByClassName("gsSubmit").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});
//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});