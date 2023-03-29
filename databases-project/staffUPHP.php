<?php
$con = mysqli_connect('localhost', 'root', '','hotel');


$sID = $_POST["sID"];
$mPay = $_POST["mPay"];

$sql = "UPDATE staff SET Monthly_Pay = '$mPay' WHERE Staff_ID = $sID";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
