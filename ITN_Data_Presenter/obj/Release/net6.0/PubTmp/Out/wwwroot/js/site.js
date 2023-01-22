function submitForm(element) {
    let page = element.getAttribute("data-page");
    console.log(page)
    document.querySelector("#pageInput").value = page;
    console.log(document.querySelector("#pageInput").value);
    let form = document.querySelector("form");
    form.submit();
}