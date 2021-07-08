import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import ParetoChart from '@/components/Chart/ParetoChart.vue'
import {mapGetters,mapActions} from "vuex";


class CausalityAnalysisMethods extends  BaseMethods{
  get MapMethods() {
    return {  ...mapActions('SpcAnalyseStore',['getCausalityAnalysisData','showSearchDialog','closeSearchDialog'])}
  }
  search=function () {
    this.getCausalityAnalysisData().then(()=>{
      this.closeSearchDialog();
      this.$refs.mychild1.drawLine();
    }).catch((error)=>{
      if(error.indexOf('drawLine')<0) {
        this.$message.warning({showClose: true, message: error, duration: 2000});
      }
    });
  }
}
class CausalityAnalysisComputed extends  BaseComputed{
  get MapComputed() {
    return {
      ...mapGetters('SpcAnalyseStore',['badList','pSortChart','productOptions','equipmentOptions']),
      ...mapGetters('CommonDictionaryStore',['productOptions','equipmentOptions'])
    };
  }
}
let view={
  methods:new CausalityAnalysisMethods(),
  computed:new CausalityAnalysisComputed()
};

export default class CausalityAnalysisView extends  BaseView {
  name='CausalityAnalysisView';
  get store() {
    return "SpcAnalyseStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    if(this.filter.productId==undefined) {
      this.showSearchDialog();
    }else{
      this.pageChange(1);
      this.search();
    }

  };
  components={
    ParetoChart
  }
}
