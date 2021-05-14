let refs = document.querySelectorAll(".nav .ref")

for (ref of refs) {
    ref.addEventListener("click", (e) => {
        old_active_ref = document.querySelector(".nav .elem .active")

        if (old_active_ref != null)
            old_active_ref.classList.remove("active")

        e.target.classList.add("active")
    })
}


let cards = document.querySelectorAll(".card")

for (card of cards) {
    card.addEventListener("click", (e) => {
        document.location.href = `/articles/${e.target.id}`
        console.log(e.target)
    })
}

let article = document.querySelectorAll(".article")[0]

if (article != undefined && article != null) {
    let likeImage = document.querySelectorAll(".article .like")[0]
    likeImage.addEventListener("click", () => {
        let xmlRequest = new XMLHttpRequest()
        xmlRequest.open("POST", `/articles/add_like/${article.id}`, true)
        xmlRequest.setRequestHeader(
            'Content-Type',
            'application/x-www-form-urlencoded; charset=UTF-8'
        );
        xmlRequest.onload = () => {
            if (xmlRequest.status == 200) {
                let likes = document.querySelectorAll(".article .like .likes_count")[0]
                likes.innerHTML = parseInt(likes.innerHTML, 10) + 1;
            }
        }
        xmlRequest.send()
    })
}

let commentImages = document.querySelectorAll(".message .like")
if (commentImages != undefined && commentImages != null) {
    for (let commentImage of commentImages) {
        commentImage.addEventListener("click", () => {
            let xmlRequest = new XMLHttpRequest()
            xmlRequest.open("POST", `/articles/comments/add_like/${commentImage.id}`, true)
            xmlRequest.setRequestHeader(
                'Content-Type',
                'application/x-www-form-urlencoded; charset=UTF-8'
            );
            xmlRequest.onload = () => {
                if (xmlRequest.status == 200) {
                    let commentLikes = document.querySelectorAll(".message .like .likes_count")[0]
                    commentLikes.innerHTML = parseInt(commentLikes.innerHTML, 10) + 1;
                }
            }
            xmlRequest.send()
        })
    }
}