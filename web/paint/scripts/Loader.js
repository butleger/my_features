var canvas = document.getElementById('table');
var ctx = canvas.getContext('2d');
var isPressed = false; 
var clicked = false;
var X, Y;
var isGradient = false

var currentTool;

var lineWidth = 5;
var majorColor = "black";
var minorColor = "black";

ctx.lineWidth = lineWidth
ctx.fillStyle = minorColor
ctx.strokeStyle = majorColor

function Loader() 
{
    this.addModule = modulePath => {
        newModule = document.createElement("script")
        newModule.src = modulePath
        document.body.append(newModule)
    }
}
const loader = new Loader()


//all in Promises because some of load parts work async and thats why all goings wrong
// new Promise((resolve, reject) => {
//     loader.addModule("scripts/paint/tools.js")
//     resolve()
// }).then(() => {
//     return new Promise((resolve, reject) => {
//         loader.addModule("scripts/paint/canvas.js")
//         resolve()
//     })
// }).then(() => (resolve, reject) => {
//     return new Promise((resolve, reject) => {
//         loader.addModule("scripts/paint/imgIO.js")
//         resolve()
//     })
// }).then((resolve) => {
//     loader.addModule("scripts/presenter.js")
//     resolve()
// }).then((resolve, reject) => {
//     loader.addModule("scripts/controller.js")
//     resolve()
// })
loader.addModule("scripts/paint/tools.js")
setTimeout(() => {
    loader.addModule("scripts/paint/canvas.js")
    loader.addModule("scripts/presenter.js")
    loader.addModule("scripts/paint/imgIO.js")
    loader.addModule("scripts/controller.js")
}, 50)
    