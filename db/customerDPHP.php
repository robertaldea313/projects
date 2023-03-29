<?php
$con = mysqli_connect('localhost', 'root', '','hotel');


$customerID = $_POST["customerID"];

$sql = "DELETE FROM customer WHERE ID = $customerID";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
