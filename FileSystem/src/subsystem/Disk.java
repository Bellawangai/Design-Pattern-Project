package subsystem;

import java.io.Serializable;
import java.util.Hashtable;
import java.util.Iterator;

public class Disk implements Serializable{
	
	private static final long serialVersionUID = 1L;
	private static Disk a = new Disk();
	private Hashtable<Integer,DiskBlock> usedlist;
	private int restNum = 100;
	
	/*当前磁盘块指针，只增不减，以防磁盘块冲突*/
	private int nowpoint=0;        

	private Disk() {
		this.usedlist = new Hashtable<Integer,DiskBlock>();
	}

	/*运用单例模式得到当前磁盘实例*/
	public static synchronized Disk getInstance() {
		return a;
	}

	public Hashtable<Integer, DiskBlock> getUsedlist() {
		return usedlist;
	}

	public void setUsedlist(Hashtable<Integer, DiskBlock> usedlist) {
		this.usedlist = usedlist;
	}

	public int getRestNum() {
		return restNum;
	}

	//restNum
	public void setRestNum(int restNum) {
		this.restNum = restNum;
	}
	
	//将某一个磁盘块上的内容保存到磁盘上
	//a为需要保存到磁盘上的某一个磁块号
	public void addUsed(DiskBlock a){
		a.setId(nowpoint);
		this.usedlist.put(nowpoint,a);
		this.restNum--;
		this.nowpoint++;
	}
	
	//将制定盘块上的内容从磁块上删除
	//a为盘块号
	public void deleteUsed(int a){
		this.usedlist.remove(a);
		this.restNum++;
	}
	
    /*打印已经使用过的磁盘块号*/
	public void showUsed() {
		System.out.println("--------------以下为已经使用的磁盘块号--------------");
		Iterator<Integer> it=usedlist.keySet().iterator();
		while(it.hasNext()) {
			System.out.print(usedlist.get(it.next()).getId() + "     ");
		}
		if (usedlist.size() > 0)
			System.out.println();
	}
}
