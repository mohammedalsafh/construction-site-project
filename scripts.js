
//this is a function that handles all the email validation in multiple pages
function validateEmail(email) {
    
      // the email must have @ and can end or start with @ 
    if (!email.includes("@") || email.startsWith("@") || email.endsWith("@")) {
        alert("Email must contain a valid @ symbol");
        return false;
    }
    
    // we reject if the user enter somthing like r@.com meaning there has to be somthing after the @ and before the .com
    var atIndex = email.indexOf("@");
    if (email.charAt(atIndex + 1) === ".") {
        alert("Email cannot have '.' immediately after '@'");
        return false;
    }
    
    // the email must have .somthing 
    var domainPart = email.split("@")[1];
    if (!domainPart.includes(".")) {
        alert("Email must contain a domain like .com or .sa");
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
    var numberPattern = /[0-9]/;
    if (!numberPattern.test(pass)) {
        alert("Password must contain at least one number");
        return false;
    }

    return true;
}

 