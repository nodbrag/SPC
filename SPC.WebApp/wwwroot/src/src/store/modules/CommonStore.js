import MutationTypes from "../MutationTypes";

const  state={
  /**
   * 数据列表总数
   */
  totalCount:0,
  /**
   * 最大分页数量
   */
  maxResultCount:15,
  /**
   * 当前记录页
   */
  skipCount:1,
  /**
   * 当前可选择的分页数
   */
  pageSelectList:[15, 25, 50, 100],
  /**
   * 当前排序字段名
   */
  sorting:'',
  /**
   * 数据列表是否加载
   */
  loading:false,
  /**
   * 新增框是否显示
   */
  addFormVisible:false,
  /**
   * 编辑框是否显示
   */
  editFormVisible:false,
  /**
   * 导入框是否显示
   */
  importFormVisible:false,
  /**
   * 选中字段数据
   */
  selectFields:[]
};

const getters = {
  loading: state => state.loading,
  editFormVisible: state => state.editFormVisible,
  addFormVisible:state=>state.addFormVisible,
  importFormVisible:state=>state.importFormVisible,
  selectFields:state=>state.selectFields,
  sorting: state => state.sorting,
  skipCount: state => state.skipCount,
  pageSelectList: state => state.pageSelectList,
  maxResultCount:state=>state.maxResultCount,
  totalCount:state=>state.totalCount

};
const  mutations= {
  [MutationTypes.SET_SKIPCOUNT](state, pageindex) {
    state.skipCount = pageindex;
  },
  [MutationTypes.SET_LOADING](state, isloading) {
    state.loading = isloading;
  },
  [MutationTypes.SET_TOTALCOUNT](state, count) {
    state.totalCount = count;
  },
  [MutationTypes.SET_EDITFORMVISIBLE](state, isshow) {
    state.editFormVisible = isshow;
  },
  [MutationTypes.SET_AddFORMVISIBLE](state, isshow) {
    state.addFormVisible = isshow;
  },
  [MutationTypes.SET_IMPORTFORMVISIBLE](state, isshow) {
    state.importFormVisible = isshow;
  },
  [MutationTypes.SET_MAXRESULTCOUNT](state, maxResultCount){
    state.maxResultCount = maxResultCount
  }
};
const  actions={
  pageChange({commit},pageindex){
    commit(MutationTypes.SET_SKIPCOUNT, pageindex);
  },

  pageSelect({commit}, maxResultCount){
    commit(MutationTypes.SET_MAXRESULTCOUNT, maxResultCount)
  }
};

export default {
  namespaced:true,
  state,
  mutations,
  actions,
  getters
}
