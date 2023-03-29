<?php
$con = mysqli_connect('localhost', 'root', '','hotel');


$customerID = $_POST["customerID"];
$fromW = $_POST["fromW"];
$toW = $_POST["toW"];

$sql1 = "UPDATE customer SET FromWhen = '$fromW' WHERE ID = $customerID";
$sql2 = "UPDATE customer SET ToWhen = '$toW' WHERE ID = $customerID";

$rs1 = mysqli_query($con, $sql1);
$rs2 = mysqli_query($con, $sql2);

if($rs1)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
