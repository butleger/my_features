let refs = document.querySelectorAll(".nav .ref")

for (ref of refs) {
    ref.addEventListener("click", (e) => {
        old_active_ref = document.querySelector(".nav .elem .active")

        if (old_active_ref != null)
            old_active_ref.classList.remove("active")

        e.target.classList.add("active")
    })
}
