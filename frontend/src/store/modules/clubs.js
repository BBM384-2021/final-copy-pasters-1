import axios from 'axios';
const resource_uri = "http://localhost:4000/api";
const club_src = '/Club/';

export default {
    namespaced: true,

state: {
    clubs: []
},

getters: {
    allClubs: state => state.clubs
},

actions:{
    async fetchClubs({ commit }) {
        const response = await axios.get(`${resource_uri}${club_src}`);  
        commit('setClubs', response.data);
    },
    async addClub( { commit }, club) {
        const response = await axios.post(`${resource_uri}${club_src}`, club);
        commit('newClub', response.data);
    },
    async updateClub( { commit }, club) {
        const response = await axios.put(`${resource_uri}${club_src}${club.id}`, club);
        commit('updClub', response.data);
    },
    async removeClub( { commit }, id) {
        const response = await axios.delete(`${resource_uri}${club_src}${id}`);
        commit('deleteClub', id);
    }
},
mutations:{
    setClubs: (state, clubs) => state.clubs = clubs,
    newClub: (state, club) => state.clubs.unshift(club),
    updClub: (state, updatedClub) => {
        const index = state.clubs.findIndex(t => t.id === updatedClub.id);
        if(index !== -1) {
            state.clubs.splice(index, 1, updatedClub);
        }        
    },
    deleteClub: (state, id) => {
        state.clubs = state.clubs.filter(t => id !== t.id);

    }
}

}