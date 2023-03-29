<?php
$con = mysqli_connect('localhost', 'root', '','hotel');


$sID = $_POST["sID"];

$sql = "DELETE FROM staff WHERE Staff_ID = $sID";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
