<html>
	<?php
  $con = mysqli_connect('localhost', 'root', '','hotel');

	$cfName = $_POST["cfName"];
	$clName = $_POST["clName"];
	$eAdress = $_POST["eAdress"];
	$cPass = $_POST["cPass"];
	$pNumber = $_POST["pNumber"];
	$fromW = $_POST["fromW"];
	$toW = $_POST["toW"];

	$sql2 = "SELECT * from `room` WHERE room.ID NOT IN
(SELECT room.ID FROM `room` INNER JOIN customer ON customer.Room WHERE room.ID=customer.Room AND customer.Room is NOT NULL);";
	$rs2 = mysqli_query($con, $sql2);
	$row = mysqli_fetch_assoc($rs2);
	$room = $row["ID"];


	$sql = "INSERT INTO customer (ID, Name, Surname, Email_Adress, Password, Phone_Number,FromWhen,ToWhen, Room)
	VALUES ('0','$cfName', '$clName', '$eAdress','$cPass', '$pNumber','$fromW','$toW','$room')";

	$rs = mysqli_query($con, $sql);

	if($rs)
	{
	echo "Contact Records Inserted";
	}
	header("Location: http://localhost/myfile2.php");
	die(); ?>
</html>
