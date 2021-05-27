<template>
    <div>
        <clubheader></clubheader>
         <!--USER INFORMATİON--->
        <div class="user-information">
            <div class="flex-body">
                <div class="user-info">
                    <!--Profile Photo-->
                    <div class="profile-photo-container">   
                        <img v-if="imageUrl===''" src="@/assets/icons/user.png" class="image-profile" >
                        <img v-else :src="imageUrl" class="image-profile" style="filter: grayscale(200%);">
                    </div>

                    <!--Username-->
                    <p style="margin-left:30%">{{username}}</p>
                    
                    <!--User Bio TextArea-->
                    <div class="bio">
                       {{biography}}
                    </div>

                    <div class="icon-area">
                        <i   @click="()=>$router.push('/private_message')" class='fa fa-paper-plane send-icon' style='font-size:20px;color:#a56a9d'></i> 
                        <h3 style="font-family:'Alegreya Sans', sans-serif;color:#a56a9d">Send Message</h3>
                    </div>


                </div>
                <div class="subclub-container">

                    <!--Subclub Info Titles-->
                    <div class="subclub-titles">
                        <div><h2 class="text">Common Sub-Clubs</h2></div>   
                    </div>
                    <div class="subclubs">
                    <div class="list-subclub"  v-for="(subclub,index) in common_subclubs" :key="index">
                        <div class="subclub-items">

                            <!--Subclub Info Img and Description--->
                            <div class="subclub-item" style="margin-left:25px">
                                    <img class="image" :src="require('@/assets/' + subclub.name + '_mini.jpeg')">
                                    <div class="desc">{{subclub.name}}</div>
                            </div>
                        </div>
                    </div>
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
        data(){
            return{
                username:this.$route.params.firstName,
                biography:"Hacettepe University",
                imageUrl:'',
                common_subclubs:[
                { 
                    id:1,
                    name:"Yoga",
                    
                },
                {  
                    id:4,
                    name:"Piano",
                
                },
                ],
            }
    },
    }
</script>
<style lang="scss" scoped>
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
        width: 60%;
        min-height:200px;
        border-radius: 15px;
       // border: 2px solid #a56a9d;
       
    }
    .subclub-titles{
        padding: 1%;
    }
    .text{
        font-size: 20px;
    }
    .subclubs{
        width: auto;
        padding: 20px;
        display: flex;
        flex-direction: row;  
        border-radius: 10px;
        border: 2px solid #a56a9d;
    
    }
    
    .subclub-item{
        width: 50px;
        height: 60px;
        display: flex;
        flex-direction: column;  
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
    
    .icon-area{
        display: flex;
        flex-direction: row;
     
    }
    .send-icon{
        margin-left: 15px;
        margin-top:15px;
        border-radius: 50px;
        margin-right: 6px;
    }
    .send-icon:hover{
        cursor: pointer;
    }
    
</style>
