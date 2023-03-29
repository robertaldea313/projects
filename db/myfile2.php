<html>
<title>
	register
</title>
<head>
<link rel="stylesheet" href="design.css">
<style>

.square{
	position:absolute;
	top:0%;
	left:30%;
	height: 100%;
	width:40%;
	background-color: #282135;
	border: 6px double;
	border-color:#F9E4D4;;
	z-index: 1;
}
</style>

</head>

<body style ="background-color: #F9E4D4; overflow:hidden" scroll="no"">
<p>
	<div class="square"></div>
<div class="center"> <b style="font-family:papyrus; font-size:30"> -Roomservice Menu- </b>  <br>
<?php
$con = mysqli_connect('localhost', 'root', '','hotel');

$sql2 = "SELECT * from `roomservice`";
$rs2 = mysqli_query($con, $sql2);
while($row = mysqli_fetch_assoc($rs2)) {
    echo "" . $row["Meal"]. " - Price: " . $row["Price"]. "$<br>";
  }
?></div>
</body></html>
