$(document).ready(function () {
    $("#tbCPassword").blur(function () {
        var pswd = $("#tbPassword").val();
        console.log(pswd);
        var cpswd = $("#tbCPassword").val();
        if (pswd != cpswd) {
            $("#PswdError").html("**Password and Confirm Password should match**");
            $("#PswdError").css({ "color": "Red" });
        }
    });

    $("#tbName").blur(function () {
        $("#nameError").html("");
        var fname = $("#tbName").val();
        console.log(fname);
        if (fname === "") {
            $("#nameError").html("Name cannot be empty**").css({ color: "red" });
            return false;
        }
        return true;
    });

    $("#tbEmail").blur(function () {
        $("#emailError").html("");
        var email = $("#tbEmail").val();
        var emailRegEx = new RegExp(
            /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
        );
        if (email === "") {
            $("#emailError").html("Email cannot be empty**").css({ color: "red" });
            return false;
        } else {
            if (!emailRegEx.test(email)) {
                $("#emailError").html("Invalid Email Address").css({ color: "red" });
                return false;
            }
        }
        return true;
    });

    $("#tbZipcode").blur(function () {
        $("#zipcodeError").html("");
        var zipcode = $("#tbZipcode").val();
        console.log(zipcode);
        if (zipcode === "") {
            $("#zipcodeError").html("Zipcode cannot be empty**").css({ color: "red" });
            return false;
        }
        return true;
    });
});