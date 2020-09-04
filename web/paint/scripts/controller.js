//change tool to another(remove old handlers and add new )
const setTool = newTool => {
    if (currentTool != undefined)
    {
        for ( event of currentTool.Events )
        {
            canvas.removeEventListener(event.eventName, event.eventHandler)
        }
    }
    
    currentTool = newTool
    for (let i = 0 ; i < newTool.Events.length ; i++) 
    {
        canvas.addEventListener(newTool.Events[i].eventName, newTool.Events[i].eventHandler)
    }    
}

//add tools changing
for (tool of Tools)
{
    let toolElement = document.getElementById(tool.id)
    toolElement.addEventListener("click", (event) => {
        let newTool =  Tools.find((tool) => {return event.target.parentElement.getAttribute("id") == tool.id})
        //if all goings wrong
        
        if (newTool == undefined)
        {
            let result = ""
            for (key in event.target)
                result += key + " : " + event.target[key] + "\n"
            console.log("All is fucked!\n Trying to found : " + result)
        }
        else 
        {
            setTool(newTool)
        }
    })
}

let leftColorPicker = document.getElementById("leftColorPicker")
leftColorPicker.addEventListener("input", event => {
    majorColor = leftColorPicker.value
    ctx.strokeStyle = majorColor
})

let rightColorPicker = document.getElementById("rightColorPicker")
rightColorPicker.addEventListener("input", event => {
    minorColor = rightColorPicker.value
    ctx.fillStyle = minorColor
})

let widthPicker = document.getElementById("widthPicker")
widthPicker.addEventListener("input", event => {
    lineWidth = widthPicker.value
    ctx.lineWidth = lineWidth
})

let isGradientElement = document.getElementById("isGradient")
isGradientElement.addEventListener("input", event => {
    if (isGradient)
    {
        isGradient = !isGradient
        ctx.fillStyle = minorColor
        ctx.strokeStyle = majorColor
    }
    else 
    {
        isGradient = true
    }
})