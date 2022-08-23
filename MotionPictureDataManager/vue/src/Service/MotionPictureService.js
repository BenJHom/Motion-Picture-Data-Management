import axios from 'axios';

const baseURL = "https://localhost:5001/api/motionpicture";

export default{
    
    getAllMotionPictures(){
        return axios.get(baseURL);
    },

    addMotionPicture(motionpicture){
        return axios.post(baseURL, motionpicture);
    },

    updateMotionPicture(motionpicture){
        return axios.put(baseURL, motionpicture);
    },

    deleteMotionPicture(id){
        return axios.delete(baseURL+`/${id}`);
    }
}