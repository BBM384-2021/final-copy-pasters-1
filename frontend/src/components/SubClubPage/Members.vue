<template>
<div class="main">
    <div class="admin-wrapper">
        <p id="admin">Sub-Club Admin</p>
        <img src="~@/assets/profile-photos/user1.png">
        <p class="name">{{subClubAdmin.firstName}}</p>
    </div>
    <fieldset class="members-wrapper">
        <legend>Members</legend>
        <div class="members"  v-for="member in members" :key="member">
            <div class="member-wrapper">
                <img src="~@/assets/profile-photos/user1.png">
                
                <router-link class="name" :to="`/profile_page/${member.firstName}`">{{member.firstName}}</router-link>
            </div>
        </div>
    </fieldset>
</div>
</template>

<script>
export default {
    data() { 
        return{
            subClubAdmin: 
            {
                id: 0,
                firstName: "Joe",
                email: "admin@gmail.com",
                role: "sub-club-admin",
                created: "2021-05-26T14:41:11.607Z",
                updated: "2021-05-26T14:41:11.607Z",
                isVerified: true
            },
            members:[
                {
                id: 0,
                firstName: "Erick",
                email: "erick@gmail.com",
                role: "member",
                created: "2021-05-26T14:41:11.607Z",
                updated: "2021-05-26T14:41:11.607Z",
                isVerified: true
                },
                {
                id: 0,
                firstName: "Jesse",
                email: "jes@gmail.com",
                role: "member",
                created: "2021-05-26T14:41:11.607Z",
                updated: "2021-05-26T14:41:11.607Z",
                isVerified: true
                },
                {
                id: 0,
                firstName: "Jane",
                email: "jes@gmail.com",
                role: "member",
                created: "2021-05-26T14:41:11.607Z",
                updated: "2021-05-26T14:41:11.607Z",
                isVerified: true
                },
            ]
            
        }

    }    

}
</script>

<style scoped lang="scss">
main{
    display: grid;
    grid-template-columns: 1fr;
    grid-template-rows: 1fr 2fr;
    grid-template-areas: "admin"
                        "members";
}
img{
    width: 5%;
    border-radius: 50%;
}
.admin-wrapper{
    grid-area: "admin";
    margin-top: 3%;
    margin-left: 10%;
    padding: 1%;
}


.members-wrapper{
    grid-area: "members";
    border: 0.2em solid rgb(175, 150, 179);
    border-radius: 2em;
    margin-top: 7%;
    margin-right: 5%;
    margin-left: 5%;
}

.members{
    padding:1%;
}

.name{
    float: right;
    margin-right: 70%;
    font-weight: 500;
    cursor: pointer;
    text-decoration: none;
    color: black;
}

p#admin{
    font-size: x-large;
}

legend{
    font-size: x-large;
    margin-left: 4%;
}

</style>
