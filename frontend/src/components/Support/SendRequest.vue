<template>
    <h5>Send a Request</h5>
    <form @submit.prevent="">
        <div class="selection_part">
            <label class="request_type">Please select a request type: </label>
            <select class="request_selection_menu" v-model="request_type">
              <option value="request_a_new_sub_club">Request a new sub-club</option>
              <option value="report_member">Report a Member</option>
              <option value="nominate">Nominate to be a sub-club admin</option>
            </select>
        </div>
          
        <div class="option_panel" v-if= "request_type === 'request_a_new_sub_club'">
                <label class="question">Please enter the sub-club name that you wish to be opened. *</label>
                <input class="sub_club_name" required>
                <label class="question">You can also write the club name that will contain the sub-club that you requested.</label>
                <input class="club_name">
          </div>
          <div class="option_panel" v-else-if= "request_type === 'report_member'">
              <label class="question">Please enter the username of the member you’d like to report. *</label>
                <input class="reported_name" required>
                <label class="question">What would you like to report about this member? *</label>
                <textarea class="report_details" required></textarea>
                <label class="question">If you have any screenshots that would help explain your report, please attach them to the ticket.</label>
                <input type="file" class="attachments">
          </div>
          <div class="option_panel" v-else-if= "request_type === 'nominate'">
                <label class="question">Please enter the name of the sub-club that you would like to be the admin of. *</label>
                <input class="sub_club_name" required>
          </div>
          <div v-if=request_type class="submit_button">
            <button class="submit" @click="()=>$router.push('/support_info')">Submit</button>
        </div>
      </form>

</template>

<script>
export default {
    data(){
        return{
            request_type:''
        }
    },
}
</script>

<style lang="scss" scoped>
    @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:ital,wght@0,400;0,500;0,700;0,800;1,400;1,500;1,700&display=swap');
    :root{
        --primary-color: #BA7EA0;
        --bolder-color: #742957;
    }

    template{
        font-family: 'Alegreya Sans', sans-serif;
    }
    h5{
        display:flex;
        justify-content:center;
        font-size:1.4em;
    }
    .selection_part{
        display:flex;
        flex-direction:column;
        justify-content:center;
        margin:5%;
        margin-top: 2%;
    }
    .request_type{
        margin:10px;
        font-size: 1.1em;
        font-weight: 500;
    }
    .option_panel{
        display:flex;
        flex-direction:column;
    }
    .request_selection_menu{
        box-sizing: border-box;
        border: 1px solid #ba7ea0e0;
        background-color: #ba7ea0e0;
        font-size: 1.1em;
        font-weight: 400;
        color:white;
        border-radius: 10px;
        height: 2em;
        padding-left:20px;
    }
    .question{
        margin:10px;
        font-size: 1.1em;
        font-weight: 500;
    }
    input{
        border: 2px solid #742957;
        border-radius: 10px;
        height:2em;
        margin-bottom: 20px;
        padding:0.5%;
    }
    .reported_name{
        height:1em;
    }
    .report_details{
        height:5em;
        border: 2px solid #742957;
        border-radius: 10px;
        padding:1%;
        margin-bottom: 20px;
    }
    .submit_button{
        margin-top: 15px;
        display:flex;
        justify-content:flex-end;

    }
    .attachments{
        border:none;
        border-radius:0;
        padding:0;
        margin:0;
    }
    
    .submit{
        background-color: #BA7EA0;
        color: white;
        cursor: pointer;
        padding: 10px;
        width: 100px;
        height:50px;
        border: .1px solid white;
        text-align: center;
        outline: none;
        transition: 0.4s;
        text-decoration: none;
        font-size: 1.2em;
        border-radius: 10px;
        font-weight: 500;
    }
</style>