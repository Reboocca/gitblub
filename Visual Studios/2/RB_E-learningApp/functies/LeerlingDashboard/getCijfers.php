<?php
    $server = "localhost";
    $user = "root"; 
    $pwd = "";
    $database = "owl-learn";
    
    $userid = $_REQUEST["uID"];

    $conn = new mysqli($server, $user, $pwd, $database);
    $sql = "select distinct toetsresultaten.Resultaat, lesonderwerp.Omschrijving, vak.Omschrijving from lesonderwerp inner join toetsresultaten on lesonderwerp.LesonderwerpID = toetsresultaten.LesonderwerpID inner join vak on lesonderwerp.VakID = vak.VakID where toetsresultaten.UserID ='$userid'";

    $result = mysqli_query($conn, $sql);

    $x=0;
	$response=array();
    while ($rij = mysqli_fetch_array($result)) {
        $response[$x]["Lesonderwerp"] = $rij[1];
        $response[$x]["Resultaat"] = $rij[0];
        $response[$x]["Vak"] = $rij[2];

        $x++;
    }

	echo json_encode($response, JSON_UNESCAPED_UNICODE);
	mysqli_close($conn);
?>