<?php
    class User{
     private $firstname;
     private $lastname;
     private $role;     
     private $place;
     private $username;
     private $pwd;
     private $salt;
     public $sql;

        public function __construct(){
            $this->getSalt();
        }

        public function getInfo($database, $args){
            $this->firstname=$args['fname'];
            $this->lastname=$args['lname'];
            $this->role=$args['role'];
            $this->place=$args['place'];
            $this->username=$args['username'];
            $this->pwd=$args['pwd1'];
            
            $this->securePwd();

            try{
                $sql = "INSERT INTO users(Username, Password, Salt, firstName, lastName, Place, Role) VALUES ('$this->username',
                                                                                                         '$this->pwd',
                                                                                                         '$this->salt',
                                                                                                         '$this->firstname',
                                                                                                         '$this->lastname',
                                                                                                         '$this->place',
                                                                                                         '$this->role')";
                if($result = mysqli_query($database->conn, $sql)){
                    echo "<p style='margin-bottom: 20px;'>You've joined the overwatch community, way to go cupcake!</br>
                                                            Now get out there and save some lives.</p>";
                }
            }
            catch(Exception $e){
                echo 'Caught exception: ', $e->getMessage(), '/n';
            }

             
        }

        public function getSalt(){
            $this->salt = dechex(mt_rand(0, 278317232)) . dechex(mt_rand(0, 278317232));
        }

        public function securePwd(){
            $this->pwd = hash('sha256', $this->pwd.$this->salt);

            for($round = 0; $round < 65536; $round++){
                $this->pwd = hash('sha256', $this->pwd.$this->salt);
            }
        }
    }
?>