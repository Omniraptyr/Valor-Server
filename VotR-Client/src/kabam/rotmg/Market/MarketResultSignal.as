package kabam.rotmg.market {
import org.osflash.signals.Signal;

public class MarketResultSignal extends Signal {
    public function MarketResultSignal() {
        super(String, Boolean);
    }
}
}
