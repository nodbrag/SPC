import MutationTypes from "../MutationTypes";

const state={
  defaultActiveIndex: "0",
  collapsed: false,
  fullscreen:false,
  nickname:""
};
const getters = {
  defaultActiveIndex: state => state.defaultActiveIndex,
  collapsed: state => state.collapsed,
  fullscreen:state=>state.fullscreen,
  nickname:state=>state.nickname
};
const actions={
  /**
   * 设置全屏函数
   * @param commit
   * @param state
   */
  handleFullScreen({commit,state}){
    let element = document.documentElement;
    if (state.fullscreen) {
      if (document.exitFullscreen) {
        document.exitFullscreen();
      } else if (document.webkitCancelFullScreen) {
        document.webkitCancelFullScreen();
      } else if (document.mozCancelFullScreen) {
        document.mozCancelFullScreen();
      } else if (document.msExitFullscreen) {
        document.msExitFullscreen();
      }
    } else {
      if (element.requestFullscreen) {
        element.requestFullscreen();
      } else if (element.webkitRequestFullScreen) {
        element.webkitRequestFullScreen();
      } else if (element.mozRequestFullScreen) {
        element.mozRequestFullScreen();
      } else if (element.msRequestFullscreen) {
        // IE11
        element.msRequestFullscreen();
      }
    }
    commit(MutationTypes.SET_FULLSCREEN);
  },
  /**
   * 选中当前菜单项
   * @param commit
   * @param index
   */
  handleSelect({commit},index){
    commit(MutationTypes.SET_DEFAULTACTIVEINDEX,{index})
  },
  /**
   * 折叠导航栏
   * @param commit
   */
  collapse: function ({commit}) {
    commit(MutationTypes.SET_COLLAPSED);
  }
};

const mutations={
  [MutationTypes.SET_FULLSCREEN](state) {
   state.fullscreen=!state.fullscreen;
  },
  [MutationTypes.SET_COLLAPSED](state) {
    state.collapsed=!state.collapsed;
  },
  [MutationTypes.SET_DEFAULTACTIVEINDEX](state,{index}) {
    state.defaultActiveIndex=index;
  },
  [MutationTypes.SET_NICKNAME](state,username){
    state.nickname=username;
  }
};

export  default
{
  namespaced:true,
  state,
  mutations,
  actions,
  getters
};
