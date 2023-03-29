<?php
$con = mysqli_connect('localhost', 'root', '','hotel');


$dID = $_POST["dID"];
$dPrice = $_POST["dPrice"];

$sql = "UPDATE roomservice SET Price = '$dPrice' WHERE ID = $dID";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
