let form = document.getElementById("LoginForm");
form.addEventListener('submit', async function (e) {
    e.preventDefault(); 

    
  
    let formData = new FormData(); // Create a new FormData object
    formData.append("username", document.getElementById("username").value);
    // formData.append("email", document.getElementById("Email").value);
    formData.append("password", document.getElementById("Password").value);

  
    
    let response = await fetch("https://localhost:44353/api/Users/LoginNew", {
        method: "POST",
        body: formData
    });
  
    if (response.ok) {
        Swal.fire({
            icon: 'success',
            title: 'User exists!',
            showConfirmButton: true,
            timer: 1500
        });
        // Optional: Redirect after success
        window.location.href = "../index.html";
    } else {
        Swal.fire({
            icon: 'error',
            title: 'User does not exist!',
            text: 'Please try again.',
            timer: 2000
        });
    }
});