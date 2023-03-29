<!DOCTYPE html>
<html>
<head><link rel="stylesheet" href="design.css">
  <style>
  .square{
	position:absolute;
  color: #282135;
	top:0%;
  left:0%;
	height: 100%;
	width:25%;
	background-color: #F9E4D4;
	border: 6px double;
	border-color:#282135;
	z-index: 1;
}
a:link, a:visited {
  background-color: #f44356;
  color: #F9E4D4;
  font-family: Garamond;
  padding: 15px 50%;
  max-width: 6px;
  left:0%;
  text-align: center;
  text-decoration: none;
  display: inline-block;
}

a:hover, a:active {
  background-color: #f44336;
}
</style></head>
<title>Customer Insert</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<body style="background-color:#282135; overflow:hidden; color:#F9E4D4" scroll="no">

<!-- Sidebar -->
<div class="square">
  <h3 style="font-family:papyrus">>Customer</h3>
  <a href="http://localhost/customerInsert.php">Insert</a><br>
  <a href="http://localhost/customerDelete.php">Delete</a><br>
  <a href="http://localhost/customerUpdate.php">Update</a><br>

  <h3 style="font-family:papyrus">>Room Service</h3>
  <a href="http://localhost/rserviceInsert.php">Insert</a><br>
  <a href="http://localhost/rserviceDelete.php">Delete</a><br>
  <a href="http://localhost/rserviceUpdate.php">Update</a><br>

  <h3 style="font-family:papyrus">>Staff</h3>
  <a href="http://localhost/staffInsert.php">Insert</a><br>
  <a href="http://localhost/staffDelete.php">Delete</a><br>
  <a href="http://localhost/staffUpdate.php">Update</a><br>
</div>

<!-- Page Content -->
<div style="margin-left:26%; margin-top:70px" >

  <center class ="center">
    <b>
    <form METHOD = POST ACTION ="http://localhost/customerIPHP.php">
    <label for="cfName">First Name:</label><br>
    <input type="text" id="cfName" name="cfName" placeholder="Your first name.." required><br>

    <label for="clName">Last Name:</label><br>
    <input type="text" id="clName" name="clName" placeholder="Your last name.." required><br>

    <label for="eAdress">Email Address:</label><br>
    <input type="email" id="eAdress" name="eAdress" placeholder="Your email address.." required><br>

    <label for="pNumber">Phone Number:</label><br>
    <input type="text" id="pNumber" name="pNumber" placeholder="Your phone number.." pattern="[+0-9]{10,}" required><br>

    <label for="cPass">Password:</label><br>
    <input type="password" id="cPass" name="cPass" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"
    title="Must contain at least one  number and one uppercase and lowercase letter, and at least 8 or more characters" placeholder="A-Z, a-z and 0-9 required.." required><br>

    <label for="fromW">From When:</label><br>
    <input type="date" id="fromW" name="fromW" min="2022-05-15" max="2023-05-15" required><br>

    <label for="toW">To When:</label><br>
    <input type="date" id="toW" name="toW" min="2022-05-15" max="2023-05-15" required><br>

    <input class="button1" style="width:75px; height:40px;" type="reset" value="Reset">
    <input class="button2" style="width:150px; height:40px;" type="submit" value="Submit">
    </b>
  </center></form>
  <div>
</html>
