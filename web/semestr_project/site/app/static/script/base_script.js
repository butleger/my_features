let refs = document.querySelectorAll(".nav .ref")

for (ref of refs) {
    ref.addEventListener("click", (e) => {
        old_active_ref = document.querySelector(".nav .elem .active")

        if (old_active_ref != null)
            old_active_ref.classList.remove("active")

        e.target.classList.add("active")
    })
}

/*
let login_form = document.querySelectorAll(".login_form_wrapper form")

if (login_form != null) {
    let submit = document.querySelector(".form .submit_input")
    submit.addEventListener("click", () => {
        let xmlRequest = new XMLHttpRequest()
        xmlRequest.open("POST", "/auth/ajax", true)
        let nickname_input = document.querySelector(".login_input")
        let password_input = document.querySelector(".password_input")

        let data = `${nickname_input.name}=${nickname_input.value}` + "&" +
            `${password_input.name}=${password_input.value}`

        xmlRequest.setRequestHeader(
            'Content-Type',
            'application/x-www-form-urlencoded; charset=UTF-8'
        );

        xmlRequest.onload = () => {
            if (xmlRequest.status == 200)
                document.location.href = "/auth/home"
            else {
                errorBlock = document.querySelector(".error_wrapper")
                errorBlock.innerHTML += `<div class='message'>${xmlRequest.responseText}</div>`
            }
        }

        xmlRequest.send(data)
    })
}

*/