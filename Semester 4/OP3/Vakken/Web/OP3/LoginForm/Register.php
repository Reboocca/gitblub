<!DOCTYPE html>
<?php
	session_start();
?>
<html class="full" lang="en">
	<head>
		<title>Overwatch</title>
		<meta charset="UTF-8">
		<link href="css/bootstrap.css" rel="stylesheet">
		<link href="css/inlog.css" rel="stylesheet">
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
	</head>
	<body>
        <?php
            include_once 'DBSclass.php';
            include_once 'User.php';
            $database = new dbs();
        ?>
		<div class="container">
			<div class="vertical-center-reg col-md-offset-3 col-md-6 col-xs-offset-1 col-xs-10 login">
				<div class="row" style="background: #96d69e;">
					<h1>
						Welcome to Overwatch
					</h1>
				</div>
				<p class="row lead">
					Fill in the form and become your own hero today!
				</p>
				<form class="row form" action="" method="POST">
                    <div class="col-xs-10 col-xs-offset-1" style="margin-bottom: 10px;">
						<div class="row">
							<div class="col-xs-6 form-group">
								<input type="text" name="fname" id="fname" placeholder="Firstname" required/>
							</div>
							<div class="col-xs-6 form-group">
								<input type="text" name="lname" id="lname" placeholder="Lastname" required/>
							</div>
						</div>
                        
                        <div class="row">
							<div class="col-xs-12 form-group">
								<select name="role" id="role">
								<option value="0" selected>-- Select an item -- </option>
                                    <?php
                                        $database->roles();
                                    ?>
                                    </select>
							</div>
						</div>

                        <div class="row">
							<div class="col-xs-12 form-group">
								<input type="text" name="place" id="place" placeholder="Base" required/>
							</div>
						</div>

                        <div class="row">
							<div class="col-xs-12 form-group">
								<input type="text" name="username" id="username" placeholder="Username" required/>
							</div>
						</div>

                        <div class="row">
							<div class="col-xs-6 form-group">
								<input type="password" name="pwd1" id="pwd1" placeholder="Password" required/>
							</div>
							<div class="col-xs-6 form-group">
								<input type="password" name="pwd2" id="pwd2" placeholder="Confirm password" required/>
							</div>
						</div>
                    </div>		
                    <button type="submit" style='margin-bottom: 25px;' name="Register">Register</button>
                    <br/>
                    <?php
                        if(isset($_POST) && isset($_POST['Register'])){	
                            if($_POST["pwd1"]==$_POST["pwd2"]){
                                $register = new User();
                                $register->getInfo($database, $_POST);
                            }
                           else{
                               echo "<p style='margin-bottom: 20px;'>Make sure the passwords are the same.</p>";
                           }
                        }
                    ?>
				</form>
			</div>
		</div>
		<script src="js/main.js"></script>
	</body>
</html>