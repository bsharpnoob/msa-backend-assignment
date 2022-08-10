const button = document.getElementById("button");

button.addEventListener("click", () => {
    alert("hi");
    fetch("https://localhost:44329/Poke/ability?name=flame-body")
        .then(res => {
            return res.json();
        })
        .then(res => {
            console.log(res)
        })
        .catch(error => {
            console.log(error);
        })
})

