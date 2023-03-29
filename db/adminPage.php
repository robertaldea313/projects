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
<title>Admin Page</title>
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
<div style="margin-left:26%; margin-top:20%">

<div>
  <h1>Maintenance page</h1>
</div>


<div>
<h2>Please choose the required task from the sidebar</h2>
<p>Do not modify customer data without customer consent.</p>
<p>All other changes to the database must be communicated afterwards.</p>
</div>

</div>

</body>
</html>
