//this is a function that handles all the email validation in multiple pages
function validateEmail(email) {

  // the email must have @ and can end or start with @ 
  if (!email.includes("@") || email.startsWith("@") || email.endsWith("@")) {
    //.include check if the string we have contains this specific char
    //.startwith check if the string we have start this specific char
    //.endwith check if the string we have end this specific char
    alert("Email must contain a valid @ symbol");
    return false;
  }

  // we reject if the user enter somthing like r@.com meaning there has to be somthing after the @ and before the .com
  var atIndex = email.indexOf("@");//here we find the index where @ is placed and we save it in var
  if (email.charAt(atIndex + 1) === ".") {//here we return the index of @ and move 1 step ahead of it and see if that char is "." or no
    alert("Email cannot have '.' immediately after '@'");//if its true it was "." it will return a message beacuse logically . cant happen after @ immeditaly
    return false;
  }

  // the email must have .somthing 
  //.split split the string into 2 parts based on the char we gave so it will split the email into left @ right
  // having [] means we will assign the part that is on the right of @ beacuse 1 is righ 0 is left
  var domainPart = email.split("@")[1];
  if (!domainPart.includes(".")) {//if the right of @ doesnt containt .
    alert("Email must contain a domain like .com or .sa");//send message
    return false;
  }

  return true;
}

//this is a function that handles all the passwords validation in multiple pages
function validatePassword(pass) {

  // passowrd cant be less that 8 characters
  if (pass.length < 8) {
    alert("Password must be at least 8 characters long");
    return false;
  }

  //the password need atleast 1 num
  var numberPattern = /[0-9]/;//any number from 0 to 9
  if (!numberPattern.test(pass)) {//.test compare both of the give patterns in ragix and return true or false 
    //if the .test value was true they are the same it will not send the alert and not start the if statment beacuse of "!"
    alert("Password must contain at least one number");
    return false;
  }

  return true;//for the final acceptance of the form if everything was correct
}

// Grand total variable to keep track of the total price in the cart, deinfed globally so it can be accessed inside the addToCart function.
var grandTotal = 0;
/* add to cart function that has 3 parameters,  */

function addToCart(productId, productName, productPrice, productImageSrc) {
  //used to create unique row ids for each product added to the cart.

  var rowId = 'cart-row-' + productId;
  var existingRow = document.getElementById(rowId);
  var cartBody = document.getElementById('cart-body');
  var cartFoot = document.getElementById('cart-foot');

  //in this if we check if the product is already in the cart by checking if the row with the specific id exists.
  if (existingRow) {
    var quantity = document.getElementById('quantity-' + productId);
    var newQuantity = parseInt(quantity.value) + 1;
    //updating the quantity of the item in the cart.
    quantity.value = newQuantity;
    quantity.value = newQuantity;
  }
  //in this if we add a new row for the product if it doesnt exist in the cart.
  else if (!existingRow) {
  //creating a new row dynamically using javs script for the product.
  //we use newRow to write the whole layout of the table then we use innerHTML to add it to the cart body.
    var newRow = '<tr id="' + rowId + '">';
    newRow += '<td><img src="' + productImageSrc + '" alt="' + productName + '" width="50"></td>';
    newRow += '<td>' + productName + '</td>';
    newRow += '<td><input type="number" id="quantity-' + productId + '" value="1" min="1" max="50"></td>';
    newRow += '<td>' + productPrice.toFixed(2) + ' SR</td>';
    newRow += '</tr>';
    cartBody.innerHTML += newRow;




  }
  //updating the grand total each time a product is added to the cart.
  grandTotal += parseFloat(productPrice);
  var total = document.getElementById('total-cell');
  total.innerHTML = grandTotal.toFixed(2) + ' SR';
  //after a user adds a product it automatically takes them to the cart section of the page
  showPage('cart-section');

  checkCart();

}

  /*the function showPage is the function used in our website to seperate the store and the cart section from each other*/ 
function showPage(pageId) {
  var storePage = document.getElementById('store-section');
  var cartPage = document.getElementById('cart-section');
  //sets both pages styles to display none
  storePage.style.display = 'none';
  cartPage.style.display = 'none';
//then takes the pageID from the parameter of the function and its display is set to block
  var pageToShow = document.getElementById(pageId);
  pageToShow.style.display = 'block';
//this expression is for when the user is in the cart section and wants to return to the store section, after the user clicks the 'show store' button the pageID passed to this function will be store-section.
  if (pageId === 'store-section') {
// the function filter products is used here to make all the products show for when the pageID is store-section
    filterProducts('all');
  }
}

function filterProducts(category) {
//function that will seperate all the products from each other or make them all visible, basically does filtering to the product chosen by the user from the drop-down menu
  var allProducts = document.getElementsByClassName('product-item');

  for (var i = 0; i < allProducts.length; i++) {
    var product = allProducts[i];

    // The first part of the condition checks if the selected category is 'all'
    // The second part checks if the product belongs to the selected category by checking its class list.
    // for example if the user chose electronics , product which is the variable above has the class list of allProducts(all products contains all the products in the store) so we check if it contains electronics.
    // if either condition is true we display the product otherwise we hide it. 
    if (category === 'all' || product.classList.contains(category)) {
      product.style.display = 'block';
    } else {
      product.style.display = 'none';
    }
  }
}


// the parameters are (the main image id given by id in html, the new image src)
function changeProductImage(imageId, newSrc) {

//we get the main image and assign it to the new var
  var imageElement = document.getElementById(imageId);

//the main image src will get the vlue of the new src so the new src will be the main image
  imageElement.src = newSrc;
}


// if more than 1 row means at least 1 product
function checkCart() {
  var table = document.getElementById("cart-table");// we get our cart by its id in html
  var rows = table.rows.length;// we check if it has any rows in the table meaning it has any items or still empty

  if (rows > 1) {//if the row is > 1 meaning it has at least 1 item
    document.getElementById("payment-button-container").innerHTML =
      "<a href='payment.html'><button class='payment-btn-nav'>Proceed to Payment</button></a>";
      //get the dive of the button id from html and insert a new button and place it into it with the given style
      //and make it a link to the payment page
  }
}

