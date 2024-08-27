

let form = document.getElementById("categoryForm");
form.addEventListener('submit', async function (e) {
    e.preventDefault(); 
  
    let formData = new FormData(); // Create a new FormData object
    formData.append("CategoryName", document.getElementById("categoryName").value);
    formData.append("CategoryImage", document.getElementById("categoryImage").files[0]);
  
    
    let response = await fetch("https://localhost:44353/api/CategoriesController1", {
        method: "POST",
        body: formData
    });
  
    if (response.ok) {
        alert("Category added successfully!");
        // window.location.href = "index.html";
    } else {
        alert("Failed to add category. Please try again.");
    }
  });
  