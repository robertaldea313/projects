<?php
$con = mysqli_connect('localhost', 'root', '','hotel');


$dID = $_POST["dID"];

$sql = "DELETE FROM roomservice WHERE ID = $dID";

$rs = mysqli_query($con, $sql);

if($rs)
{
echo "Contact Records Inserted";
}
header("Location: http://localhost/adminPage.php");
die(); ?>
