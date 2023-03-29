<?php
$con = mysqli_connect('localhost', 'root', '','hotel');

$dID = $_POST["dID"];
$dPrice = $_POST["dPrice"];
$dName = $_POST["dName"];
$dDesc = $_POST["dDesc"];

$sql = "INSERT INTO roomservice (ID, Meal, Description, Price)
VALUES ('$dID','$dName', '$dDesc', '$dPrice')";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
