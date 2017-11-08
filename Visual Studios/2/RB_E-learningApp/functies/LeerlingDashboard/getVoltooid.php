<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $lesid = $_REQUEST["lesid"];
    $userid = $_REQUEST["userid"];
    
    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select distinct voortgang.LesID, les.lesNaam from les inner join voortgang on les.LesID = voortgang.LesID where voortgang.UserID ='$userid' and voortgang.LesID ='$lesid'";
    
    $result = mysqli_query($conn, $sql);

    if ($rij = mysqli_fetch_array($result)) {
        echo $rij[1];
    }
    else{
        echo "GeenResultaat";
    }
?>