for (tool of Tools)
{
        document.getElementById("tools").innerHTML += `<div id='${tool.id}'>
            <img src='${tool.imgSource}'
            </div>`
}

let toolsElement = document.getElementById("tools")

let leftColorInput = document.createElement("input") 
leftColorInput.type = "color"
leftColorInput.id = "leftColorPicker"
toolsElement.append(leftColorInput)

let rightColorInput = document.createElement("input") 
rightColorInput.type = "color"
rightColorInput.id = "rightColorPicker"
toolsElement.append(rightColorInput)

let rangeInput = document.createElement("input")
rangeInput.id = "widthPicker" 
rangeInput.type = "range"
rangeInput.value = lineWidth
toolsElement.append(rangeInput)

let isGradientWrapper = document.createElement("div")
let isGradientInput = document.createElement("input")
let isGradientLabel = document.createElement("span")
isGradientWrapper.id = "isGradientWrapper"
isGradientLabel.innerHTML = "Gradient"
isGradientLabel.style.color = "azure"
isGradientLabel.id = "isGradientLabel"
isGradientInput.id = "isGradient"
isGradientInput.value = false
isGradientInput.type = "checkbox"
isGradientWrapper.append(isGradientInput)
isGradientWrapper.append(isGradientLabel)
toolsElement.append(isGradientWrapper)

let saveButton = document.createElement("a")
saveButton.id = "saveButton"
saveButton.innerHTML = "Save"
toolsElement.append(saveButton)

let loadButton = document.createElement("a")
loadButton.innerHTML = "Load"
loadButton.id = "loadButton"
toolsElement.append(loadButton)