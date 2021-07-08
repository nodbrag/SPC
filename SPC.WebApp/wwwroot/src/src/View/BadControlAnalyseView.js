import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import BadPChart from '@/components/Chart/BadPChart.vue'
import OKPChart from '@/components/Chart/OKPChart.vue'
import {mapGetters,mapActions} from "vuex";


class BadControlAnalyseMethods extends  BaseMethods{
  get MapMethods() {
    return {  ...mapActions('SpcAnalyseStore',['getBadControlData','showSearchDialog','closeSearchDialog'])}
  }
  search=function () {
    this.getBadControlData().then(()=>{
      this.closeSearchDialog();
      this.$refs.mychild1.drawLine();
      this.$refs.mychild2.drawLine();
    }).catch((error)=>{
      this.$message.warning({showClose: true, message:  error, duration: 2000});
    });;
  }
}
class BadControlAnalyseComputed extends  BaseComputed{
  get MapComputed() {
    return {  
      ...mapGetters('SpcAnalyseStore',['badChart','productOptions','equipmentOptions']) ,
      ...mapGetters('CommonDictionaryStore',['productOptions','equipmentOptions'])
    };
  }
}
let view={
  methods:new BadControlAnalyseMethods(),
  computed:new BadControlAnalyseComputed()
};

export default class BadControlAnalyseView extends  BaseView {
  name='BadControlAnalyseView';
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
    BadPChart,
    OKPChart
  }
}
