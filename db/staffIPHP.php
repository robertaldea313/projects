<?php
$con = mysqli_connect('localhost', 'root', '','hotel');

$sID = $_POST["sID"];
$sfName = $_POST["sfName"];
$slName = $_POST["slName"];
$mPay = $_POST["mPay"];

$sql = "INSERT INTO staff (Staff_ID, Name, Surname, Monthly_Pay)
VALUES ('$sID','$sfName', '$slName', '$mPay')";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
