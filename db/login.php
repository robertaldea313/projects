<html>
<?php
  $con = mysqli_connect('localhost', 'root', '','hotel');

  $eAdress = $_POST["eAdress"];
  $cPass = $_POST["cPass"];

  $check = "@hotel.com";

if(strpos($eAdress, $check) !== false){

  $sql="select * from admin where adminEmail='".$eAdress."'AND adminPass='".$cPass."' limit 1";

    $result=mysqli_query($con,$sql);

    if(mysqli_num_rows($result)==1){
      header("Location: http://localhost/adminPage.php");
      die();
    }
    else{
        echo " You Have Entered an Incorrect Password";
        exit();
    }
    }
    else{
    $sql="select * from customer where Email_Adress='".$eAdress."'AND Password='".$cPass."' limit 1";

    $result=mysqli_query($con,$sql);

    if(mysqli_num_rows($result)==1){
        header("Location: http://localhost/myfile2.php");
        die();
      }
      else{
          echo " You Have Entered an Incorrect Password";
          exit();
      }
    }
?>
</html>
