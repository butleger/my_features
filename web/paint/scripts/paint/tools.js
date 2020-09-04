var Tools = []

function setGradient(x0, y0, x1, y1)
{
    gradient = ctx.createLinearGradient(x0, y0, x1, y1)
    gradient.addColorStop(0, minorColor)
    gradient.addColorStop(1, majorColor)
    ctx.fillStyle = gradient
    console.log(ctx.fillStyle)
}

function getGradient(x1,y1,x2,y2)
{
    let gradient = ctx.createLinearGradient(x1,y1,x2,y2)
    gradient.addColorStop(0, minorColor)
    gradient.addColorStop(1,majorColor)
    return gradient
}

//contain event name and its handler
function EventWrapper (eventName, eventHandler) { 
    this.eventName = eventName
    this.eventHandler = eventHandler
};

//contain all info about Tool(brush, pencil, and others)
function Tool(toolName, imgSource) {
    this.id = toolName
    this.imgSource = imgSource
    this.Events = []
    for (let i = 2 ; i < arguments.length ; i++)
    {
        this.Events.push(arguments[i])
    }
}

//loading Tools 
Tools.push( 
    new Tool("rectangle", "img/rectangle.png", 
        new EventWrapper("mousedown", event => {
                X = event.offsetX
                Y = event.offsetY
        }), 
        new EventWrapper("mouseup", event => {
            if (isGradient) { setGradient(X, Y, event.offsetX, event.offsetY) }
            ctx.beginPath()
            ctx.rect(X, Y,
                event.offsetX - X,
                event.offsetY - Y)
            ctx.fill()
            ctx.stroke()
            ctx.closePath()
        }) 
    )
)

Tools.push(
    new Tool("brush", "img/brush.png",
        new EventWrapper("mousedown", event => {
            isPressed = true
            ctx.beginPath()
            X = ctx.offsetX
            Y = ctx.offsetY
           // ctx.arc(event.offsetX, event.offsetY, lineWidth/20, 0, Math.PI*2)
            ctx.fill()
            ctx.stroke()
            ctx.closePath()
        }),
        new EventWrapper("mousemove", event => {
            if (isPressed)
            {

                ctx.beginPath()
                ctx.lineCap = "round"
                ctx.lineJoin = "round"
                ctx.moveTo(X,Y)
                ctx.lineTo(event.offsetX, event.offsetY)
              //  ctx.arc(event.offsetX, event.offsetY, lineWidth/20, 0, Math.PI*2)
                ctx.fill()
                ctx.stroke()
                ctx.closePath()
                X = event.offsetX
                Y = event.offsetY
            }
        }),
        new EventWrapper("mouseup", event => {
            isPressed = false
        })
    )
)

Tools.push(
    new Tool("cleaner", "img/cleaner.png", 
        new EventWrapper("click", event => {
            ctx.clearRect(0,0,600,600)
        })
    )
)

Tools.push(
    new Tool("eraser", "img/eraser.png",
        new EventWrapper("mousedown", event => {
            ctx.beginPath()
            ctx.lineWidth = lineWidth
            ctx.fillStyle = "white"
            ctx.strokeStyle = "white"
            ctx.arc(event.offsetX, event.offsetY, lineWidth/20, 0, Math.PI*2)
            ctx.fill()
            ctx.stroke()
            ctx.closePath()
            X = event.offsetX
            Y = event.offsetY
            isPressed = true
        }),
        new EventWrapper("mousemove", event => {
            if (isPressed)
            {
                ctx.beginPath()
                ctx.moveTo(X, Y)
                ctx.lineTo(event.offsetX, event.offsetY)
                ctx.fill()
                ctx.stroke()
                X = event.offsetX
                Y = event.offsetY
                ctx.closePath()
            }
        }),
        new EventWrapper("mouseup", event => {
            isPressed = false
            ctx.strokeStyle = majorColor
            ctx.fillStyle = minorColor
            X = event.offsetX
            Y = event.offsetY
        })
    )
)

Tools.push(
    new Tool("pencil", "img/pencil.png", 
        new EventWrapper("mousedown", event => {
            ctx.beginPath()
            ctx.lineWidth = 1
            ctx.strokeStyle = "black"
            isPressed = true
            X = event.offsetX
            Y = event.offsetY
            ctx.closePath()
        }),
        new EventWrapper("mousemove", event => {
            if (isPressed)
            {
                ctx.beginPath()
                ctx.moveTo(X, Y)
                ctx.lineTo(event.offsetX, event.offsetY)
                X = event.offsetX
                Y = event.offsetY
                ctx.stroke()
                ctx.closePath()
            }
        }),
        new EventWrapper("mouseup", event => {
            ctx.lineWidth = lineWidth
            isPressed = false
            ctx.fillStyle = minorColor
            ctx.strokeStyle = majorColor
        })
    )
)

Tools.push(
    new Tool("strictLine", "img/strictLine.png",
        new EventWrapper("mousedown", event => {
            X = event.offsetX
            Y = event.offsetY
        }),
        new EventWrapper("mouseup", event => {
            ctx.beginPath()
            ctx.moveTo(X, Y)
            ctx.lineTo(event.offsetX, event.offsetY)
            ctx.stroke()
            ctx.closePath()
        })
    )
)

Tools.push(
    new Tool("ellips", "img/ellips.png", 
        new EventWrapper("mousedown", event => {
            X = event.offsetX
            Y = event.offsetY
        }),
        new EventWrapper("mouseup", event => {
            ctx.beginPath()
            a = Math.abs(event.offsetX - X)/2
            b = Math.abs(event.offsetY - Y)/2
            ctx.save()
                ctx.translate((event.offsetX + X)/2, (event.offsetY + Y)/2)
                ctx.scale(a/b, 1)
                if (isGradient) { setGradient(-b, -b, b, b) }
                ctx.arc(0,0,b, 0, 2 * Math.PI)
                ctx.fill()
                ctx.stroke()
            ctx.restore()
            ctx.closePath()
        })
    )
)
