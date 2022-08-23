import axios from 'axios';

const baseURL = "https://localhost:5001/api/motionpicture";

export default{
    
    getAllMotionPictures(){
        return axios.get(baseURL);
    },

    addMotionPicture(motionpicture){
        return axios.post(baseURL);
    },

    updateMotionPicture(motionpicture){
        return axios.put(baseURL);
    },

    deleteMotionPicture(motionpicture){
        return axios.delete(baseURL);
    }
}