<template>
    <div>
        <clubheader></clubheader>
        <!--USER INFORMATİON--->
        <div class="user-information">
            <h2 style="margin-left:10%;margin-top:50px;">MEMBER INFORMATION</h2>
            <hr style=" width:90%;border: 2px solid #d6d6d6;"><!--Thick Line Between Sections--->
            <div class="flex-body">
                <div class="user-info">
                    <!--Profile Photo-->
                    <div class="profile-photo-container">
                     
                        
                        <img v-if="imageUrl===''" src="@/assets/icons/user.png" class="image-profile" >
                        <img v-else :src="imageUrl" class="image-profile" style="filter: grayscale(200%);">
                            <i  @click="onPickFile" class="fa fa-edit edit-icon" style="font-size:24px"></i>
                                <input 
                                type="file" 
                                style="display:none" 
                                ref="fileInput" 
                                accept="image/*"
                                @change="onFilePicked"> 

                    </div>

                    <!--Username-->
                    <p style="margin-left:30%">USERNAME</p>
                    
                    <!--User Bio TextArea-->
                    <div class="bio">
                        <textarea name="bio" id="bio" :placeholder="userInfo.userBio"  class="text-area" maxlength="180"></textarea>
                    </div>

                </div>
                <div class="subclub-container">

                    <!--Subclub Info Titles-->
                    <div class="subclub-titles">
                        <div class="subclub-item"><h2 class="text">My Sub-Club</h2></div>
                        <div class="subclub-item"><h2 class="text"> Score</h2></div>
                        <div class="subclub-item"> <h2 class="text">Leave Sub-Club</h2></div>    
                    </div>

                    <hr style=" width: 90%;border: 2px solid #d6d6d6;"> <!--Thick Line in Subclub Info--->

                    <div class="list-subclub"  v-for="(subclub,index) in subclubs" :key="index">
                        <div class="subclub-items">

                            <!--Subclub Info Img and Description--->
                            <div class="subclub-item" style="margin-left:25px">
                                    <img class="image" :src="require('@/assets/' + subclub.name + '_mini.jpeg')">
                                    <div class="desc">{{subclub.name}}</div>
                            </div>

                            <!--Subclub Info Score--->
                            <div class="subclub-item" style="font-size:15px;margin-left:-19px"><h2 style="    font-weight:normal;">{{subclub.score}}%</h2></div>

                             <!--Subclub Info Leave Subclub Button--->
                            <div class="subclub-item" @click="leave()">  <i class="fa fa-trash-o icon " style="font-size:20px;margin-left:50px"></i></div>
                        
                        </div>

                        <hr style=" width:90%; border: 0.1px solid #d6d6d6;" v-if="index != Object.keys(subclubs).length - 1"> <!--Thin Line in Subclub Info--->
                    </div>
                </div>
        </div>
        <!--SETTING--->
            <div class="user-setting">
                <h2 style="margin-left:10%;margin-top:50px;">SETTINGS</h2>
                <hr style=" width: 90%;border: 2px solid #d6d6d6;"><!--Thick Line Between Sections--->
               
                <div class="setting">
                   
                    <!--Change Username--->
                    <div class="change-username">
                        <p class="text" style="margin-left:120px">Change Username</p>
                        <input type="text" class="input" placeholder="username" >
                        <button class="btn-set" style="margin-left:235px;margin-top:10px;">Change Username</button>

                    </div>

                    <!--Change Password--->
                    <div class="change-password">

                        <p class="text" style="margin-left:120px">Change Password</p>
                        
                        <div class="cp" style="margin-left :150px;">

                            <div class="change-setting-items">
                                <p>Current Password</p>
                                <input type="password" class="input" placeholder="" style="margin-left:50px;font-size:30px;font-weight:bold ;" >
                            </div>

                            <div class="change-setting-items">
                                <p>New Password</p>
                                <input type="password" class="input" style="margin-left:70px;font-size:30px;font-weight:bold ;" >
                            </div>

                            <div class="change-setting-items">
                                <p>Confirm Password</p>
                                <input type="password" class="input" style="margin-left:48px;font-size:30px;font-weight:bold ;">
                            </div>

                        </div>
                        
                        <button class="btn-set"  style="margin-left:400px">Change Password</button>
                    
                    </div>

                    <!--Delete Account--->
                    <div class="delete-account">
                        <p class="text" style="margin-left:200px">Delete Account</p>
                        <p style="margin-left:270px">Everything related to this account will be deleted.</p>
                        <button class="btn-set" style="margin-left:330px">Delete Account</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import SubClubPageHeader from "../components/SubClubPage/SubClubPageHeader.vue";
    export default {
        components : {
            "clubheader" : SubClubPageHeader,
       },
         methods:{
            leave(subclub){
               alert("Do you want to leave the club?");
               this.subclubs.splice(this.subclubs.indexOf(subclub), 1);
            },
            onPickFile(){
                this.$refs.fileInput.click();
            },
            onFilePicked(event){
                const files = event.target.files;
                let filename=files[0].name;
                if(filename.lastIndexOf('.')<= 0){
                    return alert('Please add a valid file !')
                }
                const fileReader = new FileReader();
                fileReader.addEventListener('load' , () =>{
                    this.imageUrl=fileReader.result
                })
                fileReader.readAsDataURL(files[0])
                this.image=files[0]

                console.log(files[0])
            }


       }
       ,
       data(){
        return{
            image:null,
            imageUrl:'',
            selected_subclubs:[],
            subclubs:[
             { 
                id:1,
	    		name:"Yoga",
	    		score:70,
               	
	    	},

            {  
                id:4,
	    		name:"Piano",
	    		score:90,
               
	    	},

            ],
            userInfo:{
                userId:"",
                username:"",
                userProfilePhotoPath:"",
                userPassword:"",
                userBio:"Hacettepe University | CS 22'\n Software Developer  "

            }

        }
    },
    }
</script>

<style scoped lang="scss">

    @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:wght@500&display=swap');
    * {
      font-family:'Alegreya Sans', sans-serif;
    }

    .flex-body{
        margin:20px;
        padding: 3%;
        display: flex;
        flex-direction: row;  
        justify-content: space-evenly;
    }
    .user-information{
        padding: 10px;
        display: flex;
        flex-direction: column;  
        justify-content:space-evenly;
        //align-self:flex-start ;
        
    }

    .bio{
        padding: 3%;
        margin-left: -5px;
        border-radius: 15px;
        width: 200px;
        height: 100px;
        border: 2px solid #a56a9d;
    }

    .profile-photo-container{
        display: flex;
        flex-direction: row;  
        justify-items: baseline;
        margin-left: 25px;
        width: 150px;
        height: 150px;
        border-radius: 50%;
        border: 1px solid #a56a9d;
    }
    .subclub-container{
        display: flex;
        flex-direction: column;  
        justify-content: space-evenly;
        width: 60%;
        min-height:200px;
        border-radius: 15px;
        border: 2px solid #a56a9d;
    }
    .subclub-titles{
        padding: 1%;
        display: flex;
        flex-direction: row;  
        justify-content: space-around;
    }
    .text{
        font-size: 20px;
    }
    .list-subclub{
        display: flex;
        flex-direction: column;  
        justify-content: space-evenly;

    }
    .subclub-items{
        padding: 1%;
        display: flex;
        flex-direction: row;  
        justify-content: space-around;
    }

    .subclub-item{
        width: 150px;
        height: 60px;
        display: flex;
        flex-direction: column;  
        justify-content: center;
    }

    .subclub-image{
        width: 50px;
        height: 50px;
        padding: 2%;
        display: flex;
        flex-direction: column;  
        justify-content: center;
    }
    .image{
        width: 50px;
        height: 50px;
        border-radius: 3px;
    }

    .desc{
        margin-left: 5px;
    }

    
    .icon:hover{
        cursor: pointer;
        color: red;
        height: 60%;
        width: 60%;
        
    }

    .input{
       height: 30px;
       padding:5px;
       margin-left:190px;
       border-radius: 5px;
       width: 230px;
       border:1px solid #919191 ;
    }
    
    *:focus {
        outline: none;
    }
    .text-area{
        height: 94px;
        width: 100%;
        border: none;
        background-color: transparent;
        resize: none;
        outline: none;
    }
    .setting{
        padding: 4px;
        display: flex;
        flex-direction: column;  
        justify-content:space-evenly;
    }
    .change-username{
        margin-left: 70px;
        display: flex;
        flex-direction: column;  
        justify-content:center;
    }
    .change-password{
        margin-left: 70px;
        display: flex;
        flex-direction: column;  
        justify-content:center;
    }
    .change-setting-items{
        padding: 5px;
        margin-left:40px;
        display: flex;
        flex-direction: row;  
    
    }

    .btn-set{
        margin-left: 390px;
        width: 150px;
        height: 40px;
        border-radius: 10px;
    }
    .btn-set:hover{
        background-color:#ba7ea0 ;
        color: white;
        cursor: pointer;
    }
    .edit-icon:hover{
        cursor: pointer;
    }

    .edit-icon{
        position: absolute;
        margin-top: 140px;
        margin-left: 120px;
    }
    .image-profile{
        object-fit: cover;
        width: 100%;
        height: 100%;
        border-radius: 50%;
    } 


</style>
