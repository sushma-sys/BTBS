function userValid() {
    // debugger
    var isFormValid = true;
    var Email, Password, ConfirmPassword, emailExp, passExp;
    Email = document.getElementById("Email").value;
    Password = document.getElementById("Password").value;
    ConfirmPassword = document.getElementById("ConfirmPassword").value;
    emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
    passExp = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*]).{12,20}$/;
    if (Email == "".trim()) {
        document.getElementById("validEmail").innerText = "*EmailId Mandatory";
        isFormValid = false;
        // return false;
    }
   else if (Email != "".trim()) {
        if (!Email.match(emailExp)) {
            document.getElementById("validEmail").innerText = "*Invalid Email";
            isFormValid = false;
            // return false;
        }
        else {
            document.getElementById("validEmail").innerText = "";
        }
    }
    if (Password == "".trim()) {
        document.getElementById("validPassword").innerText = "*Password Mandatory";
        isFormValid = false;
        // return false;
    }
    else if (Password != "".trim()) {
        if (!Password.match(passExp)) {
            document.getElementById("validPassword").innerText = "*Password should be 12 to 20 charactor length,inclde one uppercase letter,one lowercase letter,one digit and one special charecter";
            isFormValid = false;
            //return false;
        }
    }
    else {
        document.getElementById("validPassword").innerText = "";
    }

    if (ConfirmPassword == "".trim()) {
        document.getElementById("Cpass").innerText = "*ConfirmPassword Mandatory";
        isFormValid = false;
        return false;
    }
   else if (Password != ConfirmPassword) {
        document.getElementById("Cpass").innerText = "*ConfirmPassword should match with Password";
        isFormValid = false;
        // return false;
    }
    else {
        document.getElementById("Cpass").innerText = "";
    }

    if (!isFormValid) {
        return false;
    }
    else {
        //$("#formId").submit();
        document.getElementById("formId").submit();
    }
}