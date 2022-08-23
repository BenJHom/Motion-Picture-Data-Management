import axios from 'axios'

const baseURL = "http://localhost5001/api/motionpicture";

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

    deleteMotionPicture(motionpicture){
        return axios.delete(baseURL, motionpicture);
    }
}