function loadAndDrawImg(imgSrc)
{
    let img = new Image()
    img.onload = () => { 
        ctx.drawImage(img,0,0)
    }
    img.src = imgSrc
}

function getImageData()
{
    return canvas.toDataURL("image/png") 
}


