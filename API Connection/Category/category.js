
async function getAllCategories() {
    let url = "https://localhost:44353/api/CategoriesController1/GettingAllCat";
    let request = await fetch(url);

    let data = await request.json();
     

    let card = document.getElementById("container");
    data.forEach(category => {
        card.innerHTML += `
        <div class="row"> 
        <div class="card" style="width: 18rem;">
  <img class="card-img-top" src="${category.categoryImage}" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">${category.categoryName}</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="#" onclick="saveCategoryID(${category.categoryId})" class="btn btn-primary">Save ID</a>
    <a href="#" onclick="AddCategory()" class="btn btn-primary">Add Category</a>
  </div>
  
</div>
</div>
        
        `
    });
}




getAllCategories();

function saveCategoryID(x) {
localStorage.setItem("categoryID", x);
window.location.href = "../Products/products.html"
}

function AddCategory() {
  window.location.href = "addCategory.html"
}