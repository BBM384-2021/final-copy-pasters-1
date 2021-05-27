<template>
<form @submit="onSubmit">
            <input type="text" v-model="title" name ="name" 
            placeholder="Add Club">
            <input type="submit" value="Add Club" class="btn">
        </form>
    <div v-bind:key="club.id" v-for="club in allClubs">
        {{club.title}}
        {{club.id}}
        <button @click="deleteClub(club.id)">Delete</button>
    </div>

</template>

<script>
import { mapActions } from 'vuex';
import { mapGetters } from 'vuex';
import { mapState } from 'vuex';

export default {
    name: "AddClub",
    data(){
        return{
            title:''
        }
    },
    methods: {
        ...mapActions('clubs',['addClub']),
        onSubmit(e) {
            e.preventDefault();
            const club = {
                title: this.title
            }
            this.addClub(club);
        },
        
        ...mapActions('clubs',['fetchClubs']),
        ...mapActions('clubs',['removeClub', 'updateClub']),
        ChangeName() {
            const updatedClub = {
                id: this.club.id,
                title: this.title,
            };
            this.updateClub(updatedClub);
        },
        deleteClub(id) {
            this.removeClub(id);
    }
    },
    computed: {
        ...mapState('clubs',['clubs']),
        ...mapGetters('clubs',['allClubs']),
    },
    created(){
        this.fetchClubs()
    }

    
}
</script>

<style scoped>
  form {
    display: flex;
  }

  input[type="text"] {
    flex: 10;
    padding: 5px;
  }

  input[type="submit"] {
    flex: 2;    
  }
</style>