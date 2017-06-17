<?php
	$con = mysqli_connect("localhost","root","","stakeholders") or die('Geen verbinding: ' . mysqli_error());
	mysqli_set_charset($con,"utf8");

	$vendorno	= (isset($_GET['vendorno']) 	? $_GET['vendorno'] 	: false);
	$vendorname	= (isset($_GET['vendorname'])	? mysqli_real_escape_string($con, $_GET['vendorname']) 	: false);
	
	if ($vendorname) {
		$sql = "SELECT No,Description,OnHand,OnOrder,Cost 
				FROM parts 
				WHERE VendorNo = (SELECT No from vendor WHERE Name = '$vendorname')";		
	} elseif ($vendorno) {
		$sql = "SELECT No,Description,OnHand,OnOrder,Cost 
				FROM parts 
				WHERE VendorNo = '$vendorno'";	
	} else {
		$sql = "SELECT No, Name 
				FROM vendor";	
	}
	
	$result = mysqli_query($con, $sql);	

	$x=0;
	$response=array();
	while ($row = mysqli_fetch_assoc($result)) {
		if ($vendorname || $vendorno) {
			$response[$x]["No"] 			= $row["No"];
			$response[$x]["Description"] 	= $row["Description"];
			$response[$x]["OnHand"] 		= $row["OnHand"];
			$response[$x]["OnOrder"] 		= $row["OnOrder"];
			$response[$x]["Cost"]	 		= $row["Cost"];
		} else {
			$response[$x]["No"] 			= $row["No"];
			$response[$x]["Name"] 			= $row["Name"];
		}
		$x++;
	}
	echo json_encode($response, JSON_UNESCAPED_UNICODE);
	mysqli_close($con);
?>